package ru.lytvest.telecom.repository

import org.springframework.data.repository.CrudRepository
import ru.lytvest.telecom.entity.Cookie
import java.util.*

interface CookieRepository : CrudRepository<Cookie, Long> {
    fun findByCookie(cookie: String): Optional<Cookie>
}