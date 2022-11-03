using Microsoft.AspNetCore.Mvc;
using REST.DOIT.ModelDto.BaseResponse;
using REST.DOIT.ModelDto.FilterModel;
using REST.DOIT.ModelDto.Movie;
using REST.DOIT.ModelDto.Pagination;
using REST.DOIT.ModelDto.Review;

namespace REST.DOIT.Controllers
{
    [ApiController]
    [Route("api/v1/movies")]
    public class MovieController : ControllerBase
    {
        [HttpGet("")]
        public List<MovieResponseModel> GetMovies(
            [FromQuery] MovieFilter filter,
            [FromQuery] PaginationFilter pagination
        )
        {
            return new List<MovieResponseModel>();
        }

        [HttpGet("{id}")]
        public MovieResponseModel GetMovieById(int id)
        {
            return new MovieResponseModel
            {
                Id = id,
                Name = "Avenger",
                Genra = "Action"
            };
        }

        [HttpPost("")]
        public MovieResponseModel CreateMovie([FromBody] MovieRequestModel model)
        {
            return new MovieResponseModel
            {
                Id = 1,
                Name = model.Name,
                Genra = model.Genra
            };
        }

        [HttpPut("{id}")]
        public MovieResponseModel UpdateMovie(int id, [FromBody] MovieRequestModel model)
        {
            return new MovieResponseModel
            {
                Id = id,
                Name = model.Name,
                Genra = model.Genra
            };
        }

        [HttpDelete("{id}")]
        public SuccessResponseModel DeleteMovie(int id)
        {
            return new SuccessResponseModel { IsSuccess = true };
        }

        [HttpGet("{movieId}/reviews")]
        public List<ReviewResponseModel> GetReviews(int movieId)
        {
            return new List<ReviewResponseModel>();
        }

        [HttpGet("{movieId}/reviews/{reviewId}")]
        public ReviewResponseModel GetReviewById(int movieId, int reviewId)
        {
            return new ReviewResponseModel
            {
                Id = reviewId,
                Message = "Review Ja"
            };
        }

        [HttpPost("{movieId}/reviews")]
        public ReviewResponseModel CreateReview(int movieId, [FromBody] ReviewRequestModel model)
        {
            //Service add review
            int reviewId = 1; //_reviewService.AddReview(model);
            return new ReviewResponseModel
            {
                Id = reviewId,
                Message = model.Message,
                Score = model.Score
            };
        }

        [HttpPut("{movieId}/reviews/{reviewId}")]
        public ReviewResponseModel UpdateeReview(int movieId, int reviewId, [FromBody] ReviewRequestModel model)
        {
            //Service add review
            return new ReviewResponseModel
            {
                Id = reviewId,
                Message = model.Message,
                Score = model.Score
            };
        }

        [HttpDelete("{movieId}/reviews/{reviewId}")]
        public SuccessResponseModel DeleteReview(int movieId, int reviewId)
        {
            return new SuccessResponseModel
            {
                IsSuccess = true,
                ErrorMessage = ""
            };
        }
    }
}
