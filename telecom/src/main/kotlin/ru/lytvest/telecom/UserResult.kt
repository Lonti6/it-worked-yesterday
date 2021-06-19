package ru.lytvest.telecom


import ru.lytvest.telecom.entity.User

data class UserResult(
    val message: String = "",
    val cookie: String = "",
    val login: String = "",
    val firstName: String = "",
    val lastName: String = "",
    val status: Int = 200
) {
    constructor(user: User, cookie: String) : this("ok", cookie, user.login, user.firstName, user.lastName)
}

