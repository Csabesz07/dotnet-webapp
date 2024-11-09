export class StudentStatistics {

    constructor(
        name: string,
        avarage: number,
        failCount: number,
        bestGrade: number,
    ){
        this.name = name;
        this.avarage = avarage;
        this.failCount = failCount;
        this.bestGrade = bestGrade;
    }

    name: string;
    avarage: number;
    failCount: number;
    bestGrade: number;
}