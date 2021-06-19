package ru.lytvest.telecom.entity

import com.fasterxml.jackson.annotation.JsonIgnore
import java.util.*
import javax.persistence.*

@Entity
@Table(name = "notes")
data class Note(

    @Column(length = 1024)
    val message: String = "",



    @ManyToOne(cascade = [CascadeType.ALL])
    @JoinColumn(name = "user_id")
    @JsonIgnore
    val user: User = User(),

    @ManyToOne(cascade = [CascadeType.ALL])
    @JoinColumn(name = "doctor_id")
    @JsonIgnore
    val doctor: User = User(),
    @Column()
    val time: Date = Date(),
    @Column()
    val created: Date = Date(),

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id: Long = 0,

    )
