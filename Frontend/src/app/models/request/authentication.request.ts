export class AuthenticationRequest {
    constructor(
        username: string,
        password: string,
    )
    {
        this.username = username;
        this.password = password;
    }

    public username: string;
    public password: string;
}