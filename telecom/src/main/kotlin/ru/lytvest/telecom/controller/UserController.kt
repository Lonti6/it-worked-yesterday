package ru.lytvest.telecom.controller

import org.springframework.web.bind.annotation.*
import ru.lytvest.telecom.UserResult
import ru.lytvest.telecom.entity.*
import ru.lytvest.telecom.repository.CookieRepository
import ru.lytvest.telecom.repository.NoteRepository
import ru.lytvest.telecom.repository.PostRepository
import ru.lytvest.telecom.repository.UserRepository

@RestController
class UserController(
    private val userRepository: UserRepository,
    private val cookieRepository: CookieRepository,
    private val postRepository: PostRepository,
    private val noteRepository: NoteRepository
) {

    fun <T, K> workWithCookie(cookie: String?, func: (User) -> T, errorResult: (String) -> K): Any {
        if (cookie.isNullOrEmpty())
            return errorResult("no logined")!!

        val cookieOptional = cookieRepository.findByCookie(cookie)
        if (cookieOptional.isEmpty)
            return errorResult("not find cookie jj")!!

        return func(cookieOptional.get().user)!!
    }

    @GetMapping("/")
    fun simple(@RequestHeader("Cookie") cookie: String?): Any {
        return workWithCookie(cookie, {
            it
        }, { UserResult(it, status = 400) })
    }

    @PostMapping("registration")
    fun registration(@RequestBody user: User): UserResult {

        if (userRepository.findByLogin(user.login).isPresent)
            return UserResult(status = 400, message = "user already exist")

        val cookie = Cookie(user)

        userRepository.save(user)
        cookieRepository.save(cookie)

        return UserResult(user, cookie.cookie)
    }

    @PostMapping("login")
    fun login(@RequestBody user: User): UserResult {
        val optionalUser = userRepository.findByLoginAndPass(user.login, user.pass)
        if (optionalUser.isEmpty)
            return UserResult(status = 400, message = "no correct login or password")


        val userLogined = optionalUser.get()

        val cookie = Cookie(userLogined)
        cookieRepository.save(cookie)

        return UserResult(userLogined, cookie.cookie)
    }

    @GetMapping("all")
    fun all(): MutableIterable<User> {
        return userRepository.findAll()
    }

    @PostMapping("create")
    fun create(@RequestBody post: Post, @RequestHeader("Cookie") cookie: String?): Any {
        return workWithCookie(cookie, {
            post.author = it
            postRepository.save(post)
            post
        }, { UserResult(it, status = 400) })
    }

    @GetMapping("posts")
    fun allPosts(): Any {
        return postRepository.findAll()
    }

    @PostMapping("create-note")
    fun createNote(@RequestBody post: CreateNote): Any {
        post.apply {
            if (login.isNullOrEmpty() || doctor.isNullOrEmpty() || message.isNullOrEmpty())
                return UserResult(status = 400, message = "no correct data")

            val user = userRepository.findByLogin(login)
            val doctor = userRepository.findByLogin(doctor)

            if (user.isEmpty || doctor.isEmpty)
                return UserResult(status = 400, message = "not user with name $login or doctor with name $doctor")

            val note = Note(message, user.get(), doctor.get(), time)

            noteRepository.save(note)
            return UserResult(user.get(), "")

        }
    }

    @GetMapping("notes")
    fun notes(@RequestParam login: String): Any {

        if (login.isEmpty())
            return UserResult(status = 400, message = "no correct data")

        val user = userRepository.findByLogin(login)
        if (user.isEmpty)
            return UserResult(status = 400, message = "not user $login")

        return noteRepository.findByUser(user.get())

    }


}