import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Apollo, ApolloModule } from 'apollo-angular';
import { Observable } from 'rxjs';
import { GET_USERS } from 'src/app/graphql/graphql.queries';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule, ApolloModule],
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  surname = signal<string>('');
  loading = true;
  error: any;

  constructor(private apollo: Apollo) {
  }

  ngOnInit() {
    this.apollo.watchQuery({
      query: GET_USERS
    }).valueChanges.subscribe(({ data, loading, error }: any) => {
      this.surname.set(data.getUser.firstName + "-" + data.getUser.lastName);
      this.error = error;
      this.loading = loading;
    }
    );

  }

}
