export class Announcement {
    constructor(
        public id?: number,
        public title?: string,
        public description?: string,
        public date?: Date,
        public userId?: number
    ){}
}