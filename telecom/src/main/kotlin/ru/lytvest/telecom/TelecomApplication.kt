package ru.lytvest.telecom

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

@SpringBootApplication
class TelecomApplication

fun main(args: Array<String>) {
	runApplication<TelecomApplication>(*args)
}
