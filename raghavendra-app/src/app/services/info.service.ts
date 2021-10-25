import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@app-environments/environment';
import { IAboutTemple, ILatestEvents, ILatestEventsDtl, IResult, ISevaList, IUserQuery } from '@app/models/IUser';
import { Observable, of } from 'rxjs';
import { map, shareReplay, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class InfoService {
  API_URL = environment.apiUrl;
  sevaList: ISevaList[] = [];
  aboutTemple: IAboutTemple[] = [];
  latestEventList: ILatestEventsDtl[] = [];
  constructor(private http: HttpClient) {}

  getLatestEvents() {
    // let headers = new HttpHeaders();
    // headers = headers.append('Authorization', idToken);

    if (this.latestEventList.length > 0) return of(this.latestEventList);
    return this.http.get<ILatestEvents[]>(this.API_URL + 'common/latest-update').pipe(
      map((events) =>
        events.map((event) => {
          const datestring = new Date(event.eventDate).toLocaleDateString('en-GB', { day: 'numeric', month: 'short', year: 'numeric' });
          let dateArr = datestring.split(' ');
          return {
            title: event.title,
            description: event.description,
            imageUrl: event.imageUrl,
            eventDate: event.eventDate,
            day: +dateArr[0],
            month: dateArr[1],
            year: parseInt(dateArr[2]),
          } as ILatestEventsDtl;
        })
      ),
      shareReplay(),
      tap((data) => (this.latestEventList = data))
    );
  }

  getSevaList() {
    if (this.sevaList.length > 0) return of(this.sevaList);
    return this.http.get<ISevaList[]>(this.API_URL + 'common/seva-list').pipe(
      shareReplay(),
      tap((data) => (this.sevaList = data))
    );
  }

  userClarfication(contact: IUserQuery) {
    return this.http.post<IResult>(this.API_URL + 'common/clarification', contact);
  }

  getAboutTemple() {
    if (this.aboutTemple.length > 0) return of(this.aboutTemple);
    return this.http.get<IAboutTemple[]>(this.API_URL + 'common/about-guru').pipe(
      shareReplay(),
      tap((data) => (this.aboutTemple = data))
    );
  }
}
