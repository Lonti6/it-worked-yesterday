package ru.lytvest.telecom.entity


import com.fasterxml.jackson.annotation.JsonIgnore
import java.util.*
import javax.persistence.*

@Entity
@Table(name = "posts")
class Post {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id: Long = 0

    @Column
    val head: String = ""

    @Column
    val body: String = ""

    @ManyToOne(cascade = [CascadeType.ALL])
    @JoinColumn(name = "author_id")
    @JsonIgnore
    var author: User = User()
        set(value) {
            field = value
            author.posts += this
        }

    @Column
    val created: Date = Date()
    override fun toString(): String {
        return "Post(id=$id, head='$head', body='$body', created=$created)"
    }

}
