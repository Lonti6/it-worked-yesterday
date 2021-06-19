package ru.lytvest.telecom.entity

import com.fasterxml.jackson.annotation.JsonIgnore
import java.util.*
import javax.persistence.*

@Entity
@Table(name = "cookies")
class Cookie {

    @ManyToOne(cascade = [CascadeType.ALL])
    @JoinColumn(name = "user_id")
    @JsonIgnore
    var user: User = User()


    @Column
    var cookie: String = UUID.randomUUID().toString()

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id: Long = 0

    constructor()

    constructor(user: User) {
        this.user = user
    }

    override fun toString(): String {
        return "Cookie('$cookie', id=$id)"
    }

}
