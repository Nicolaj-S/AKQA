export interface CreateUser{
  UserName: string;
  FirstName: string;
  LastName: string;
  Email: String;
  Password: string;
  Admin: boolean;
  Recipe?: number[];
}
