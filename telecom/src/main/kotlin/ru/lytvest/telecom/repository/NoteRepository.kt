package ru.lytvest.telecom.repository

import org.springframework.data.repository.CrudRepository
import ru.lytvest.telecom.entity.Note
import ru.lytvest.telecom.entity.User


interface NoteRepository : CrudRepository<Note, Long> {
    fun findByDoctor(doctor: User): Collection<Note>
    fun findByUser(user: User): Collection<Note>
}