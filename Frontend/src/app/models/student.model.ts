export class Student {

    constructor(
        id: number,
        name: string,
        semester: number,
        birthday: Date,
        mobileNumber: string,
    ){
        this.id = id;
        this.name = name;
        this.semester = semester;
        this.birthday = birthday;
        this.mobileNumber = mobileNumber;
    }

    id: number;
    name: string;
    semester: number;
    birthday: Date;
    mobileNumber: string;
}