import { gql } from 'apollo-angular'


const GET_USERS = gql`
  query {
    getUser {
      id
      firstName
      lastName
    }
  }
`

const ADD_USER = gql`
  mutation addUSER($name: String!, $description: String!) {
    addUSER(name: $name, description: $description) {
      id
      name
      description
    }
  }
`

const DELETE_USER = gql`
  mutation deleteUSER($id: Int!) {
    deleteUSER(id: $id) {
      id
    }
  }
  `

export { GET_USERS, ADD_USER, DELETE_USER }
