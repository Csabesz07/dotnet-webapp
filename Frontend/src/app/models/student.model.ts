export class Student {

    constructor(
        name: string,
        semester: number,
        birthday: Date,
        mobileNumber: string,
    ){
        this.name = name;
        this.semester = semester;
        this.birthday = birthday;
        this.mobileNumber = mobileNumber;
    }

    name: string;
    semester: number;
    birthday: Date;
    mobileNumber: string;
}