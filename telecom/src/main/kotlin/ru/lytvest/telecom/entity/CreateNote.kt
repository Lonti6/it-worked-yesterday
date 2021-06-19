package ru.lytvest.telecom.entity

import com.fasterxml.jackson.annotation.JsonIgnore
import java.util.*
import javax.persistence.CascadeType
import javax.persistence.Column
import javax.persistence.JoinColumn
import javax.persistence.ManyToOne

data class CreateNote(
    val login: String? = "",
    val message: String? = "",
    val time: Date = Date(),
    val doctor: String? = ""
)
