﻿using CloudComputingAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudComputingAPI.Services
{
    public interface IMoviesService
    {
        Task AddMovieToFavorites(int user_id, int movie_id);
        Task RemoveMovieFromFavorites(int user_id, int movie_id);
        Task<IEnumerable<int>> GetAllFavorites(int user_id);
    }
}
