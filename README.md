# Zigzag test API.

To run this application you need a mongodb instance (connection string and db name provided in `appsettings.json`).
After starting the application you'll see a swagger page. Register user in `Auth/register` endpoint and get the JWT token from `Auth/token`. Now you can add the JWT token by clicking `Authorize` button, format: `Bearer <jwt-token>`. After that you're able to use swagger.

To run the ui application all you need is run `npm install` and provide 'BASE_URL' constant value in 'commonConstants' object.

This application contains some GraphQl features accessible by 'https://localhost:5001/graphql'. There is a query for getting all animes from the database with filtering and creating mutation. Example:
  ```
query {
  all {
    name
    description
    rating
  }
}
  ```
  
Query with where clause example:
```
query {
  all(where: {name: {eq: "Naruto"}}) {
    name
    description
    rating
  }
}
  ```
Mutation for creating a new anime example:
  ```
mutation{
  createAnime(domain: {
    id: "e8cc2778-8965-459c-a0f5-1f41651b3f4e"
    name: "Name",
    description: "Desc",
    rating: 10,
    numberOfEpisodes: 5,
    categoryName: "Category"
    releaseDate: "2018.12.12"
  }) {
    name
  }
}
  ```
