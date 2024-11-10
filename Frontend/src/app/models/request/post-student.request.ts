export class PostStudentRequest {

    constructor(
        name: string,
        semester: number,
        birtday: Date,
        mobileNumber: string
    ) {
        this.name = name;
        this.semester = semester;
        this.birthday = birtday;
        this.mobileNumber = mobileNumber;
    }

    public name: string;
    public semester: number;
    public birthday: Date;
    public mobileNumber: string;
}