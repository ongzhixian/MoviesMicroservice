import { gql } from "apollo-angular";

const GET_MOVIES = gql `
query {
    movies
    {
        id name rate
    }
}
`;

const CREATE_MOVIE = gql`
mutation ($movie: MovieInput!)
{
    createMovie(movie: $movie)
    {
        id
    }
}
`;

const UPDATE_MOVIE = gql`
mutation ($movie: MovieInput!)
{
    updateMovie(movie: $movie)
    {
        id
    }
}
`;


export { GET_MOVIES, CREATE_MOVIE, UPDATE_MOVIE };