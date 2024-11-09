export class StudentStatistics {

    constructor(
        id: number,
        name: string,
        avarage: number,
        failCount: number,
        bestGrade: number,
    ){
        this.id = id;
        this.name = name;
        this.avarage = avarage;
        this.failCount = failCount;
        this.bestGrade = bestGrade;
    }

    id: number;
    name: string;
    avarage: number;
    failCount: number;
    bestGrade: number;
}