package ru.lytvest.telecom.entity

import com.fasterxml.jackson.annotation.JsonIgnore
import javax.persistence.*

@Entity
@Table(name = "users")
class User(
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id: Long = 0,

    @Column(length = 50)
    val login: String = "",

    @Column(length = 100)
    val pass: String = "",

    @Column(length = 50)
    val firstName: String = "",

    @Column(length = 50)
    val lastName: String = "",

    @Column(length = 50)
    val email: String = "",

    @Column(length = 10)
    val role: String = "user",

    @OneToMany(mappedBy = "author", fetch = FetchType.LAZY)
    var posts: Set<Post> = setOf(),


    @OneToMany(mappedBy = "user", fetch = FetchType.EAGER)
    var cookies: Set<Cookie> = setOf()


    ) {


    override fun toString(): String {
        return "User(id=$id, login='$login', pass='$pass', firstName='$firstName', lastName='$lastName', email='$email', role='$role', posts=$posts, cookies=$cookies)"
    }


}
