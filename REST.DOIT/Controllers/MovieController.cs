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

        [HttpGet("Task")]
        public string DoTask()
        {
            int shared = 0;
            Task task1 = Task.Run(() =>
            {
                Console.WriteLine(shared);
                string res = DoHeavyComputation(15000);
                shared++;
                Console.WriteLine("Finish Task1 " + shared);
            });

            Task task2 = Task.Run(() =>
            {
                Console.WriteLine(shared);
                string res = DoHeavyComputation(20000);
                shared++;
                Console.WriteLine("Finish Task 2 " + shared);
            });

            Task task3 = Task.Run(() =>
            {
                Console.WriteLine(shared);
                string res = DoHeavyComputation(22000);
                shared++;
                Console.WriteLine("Finish Task 3 " + shared);
            });

            return "Don wait";
        }

        private string DoHeavyComputation(int length)
        {
            string result = string.Empty;

            Random rand = new Random();
            int arrLength = length;
            List<int> arr = new List<int>();

            // Populate List
            for (int i = 0; i < arrLength; i++)
            {
                arr.Add(rand.Next(Int32.MaxValue));
            }
            // Bubble Sort
            int temp = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                for (int sort = 0; sort < arr.Count - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
                result += arr[i].ToString() + ", ";
            }

            return result;
        }
    }
}
