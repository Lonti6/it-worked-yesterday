package ru.lytvest.telecom.repository

import org.springframework.data.repository.CrudRepository
import ru.lytvest.telecom.entity.Cookie
import ru.lytvest.telecom.entity.User
import java.util.*

interface UserRepository : CrudRepository<User, Long> {

    fun findByLoginAndPass(login: String, pass: String): Optional<User>
    fun findByLogin(login: String): Optional<User>
    fun findByCookies(cookie: Cookie): Optional<User>
}

