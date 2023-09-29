import React from "react";
import { gql, useQuery } from "@apollo/client";

// The query for the `Dog` component is close to the component
export const GET_USER_QUERY = gql`
  query GetUserByName {
    getUser {
      id
      firstName
      lastName
    }
  }
`;
export const User = () => {
  const { loading, error, data } = useQuery(
    GET_USER_QUERY
    // { variables: { name } }
  );
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error!</p>;

  return (
    <p>
      {data.getUser.firstName} - {data.getUser.lastName}
    </p>
  );
};
