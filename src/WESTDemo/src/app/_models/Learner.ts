import { Course } from "./Course";
import { Group } from "./Group";

export class Learner {
    id: number;
    userId: number;
    groupId: number;
    firstname: string;
    username: string;
    lastname: string;
    group: Group;
    status: boolean;
    learnerStatus: Course[];
}