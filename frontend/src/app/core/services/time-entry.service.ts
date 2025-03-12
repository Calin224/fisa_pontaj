import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { TimeEntry } from '../../shared/models/timeEntry';

@Injectable({
  providedIn: 'root'
})
export class TimeEntryService {
  baseUrl = "https://localhost:5001/api/";
  http = inject(HttpClient);

  addTimeEntry(entry: TimeEntry){
    const userId = localStorage.getItem('userId');
    if(userId){
      entry.userId = userId;
    }
    return this.http.post(this.baseUrl + 'timeentries', entry, {withCredentials: true});
  }

  getUserTimeEntries(){
    return this.http.get<TimeEntry[]>(this.baseUrl + 'timeentries');
  }
}
