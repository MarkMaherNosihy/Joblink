import { Experience } from "./Experience";
import { User } from "./User";

export interface Employee extends User {
    firstName: string,
    lastName: string,
    gender: string,
    cV_Url: string,
    experiences: Experience[]

}