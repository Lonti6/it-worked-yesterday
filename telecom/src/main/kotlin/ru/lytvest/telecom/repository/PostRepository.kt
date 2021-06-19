package ru.lytvest.telecom.repository

import org.springframework.data.repository.CrudRepository
import ru.lytvest.telecom.entity.Post

interface PostRepository : CrudRepository<Post, Long>