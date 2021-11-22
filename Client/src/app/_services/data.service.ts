import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Announcement } from '../models/Announcement';
import { Observable } from 'rxjs';

@Injectable()
export class DataService {

    private url = "http://localhost:43275/announcements/";

    constructor(private http: HttpClient) {
    }

    getAnnouncements(): Observable<any> {
        return this.http.get<Announcement[]>(this.url);
    }

    getAnnouncement(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createAnnouncement(announcement: Announcement) {
        return this.http.post(this.url, announcement);
    }
    updateAnnouncement(announcement: Announcement) {

        return this.http.put(this.url, announcement);
    }
    deleteAnnouncement(id: number | undefined) {
        return this.http.delete(this.url + '/' + id);
    }
}