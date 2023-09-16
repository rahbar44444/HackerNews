# Hacker News Best Stories API

This ASP.NET Core Web API allows you to retrieve the best n stories from the Hacker News API, sorted by score.

## Getting Started

Follow these steps to set up and run the API locally.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (optional)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/rahbar44444/HackerNews.git

### Navigate to the project directory:
cd hacker-news-api

### Build and run the application:
dotnet build
dotnet run

### Usage
### To retrieve the best n stories from the Hacker News API, make a GET request to the following endpoint:
GET http://localhost:5000/api/hackernews/best-stories?n={n}

### Replace {n} with the number of best stories you want to retrieve. Find below example,
### Example Request
GET http://localhost:5000/api/hackernews/best-stories?n=10

### Example Response
[
  {
    "title": "A uBlock Origin update was rejected from the Chrome Web Store",
    "uri": "https://github.com/uBlockOrigin/uBlock-issues/issues/745",
    "postedBy": "ismaildonmez",
    "time": "2019-10-12T13:43:01Z",
    "score": 1757,
    "commentCount": 588
  },
  // Additional stories...
]

### Configuration
You can configure the API by modifying the App.config file to set the base URLs for the Hacker News API.



