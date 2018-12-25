import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CustomFormsModule } from 'ng2-validation'

import { AppComponent } from './app.component';
import { RegistrationListComponent } from './components/records/registration/registration-list/registration-list.component';
import { RegistrationAddComponent } from './components/records/registration/registration-add/registration-add.component';
import { RegistrationEditComponent } from './components/records/registration/registration-edit/registration-edit.component';
import { RegistrationDetailsComponent } from './components/records/registration/registration-details/registration-details.component';
import { AttendanceListComponent } from './components/records/attendance/attendance-list/attendance-list.component';
import { AttendanceAddComponent } from './components/records/attendance/attendance-add/attendance-add.component';
import { AttendanceDetailsComponent } from './components/records/attendance/attendance-details/attendance-details.component';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { OpdHttpService } from './http/opd-http.service';
import { RegisterHttpService } from './http/register-http.service';
import { FindPatientResolverService } from './resolvers/patient/find-patient-resolver.service';
import { PatientsResolverService } from './resolvers/patient/patients-resolver.service';
import { AttendanceHttpService } from './http/attendance-http-service';
import { AttendanceResolverService } from './resolvers/attendance/attendance.service';
import { AddOpdComponent } from './components/opd/add-opd/add-opd.component';
import { VitalsResolverService } from './resolvers/vitals/vitals-resolver.service';
import { ListOpdComponent } from './components/opd/list-opd/list-opd.component';
import { AboutComponent } from './components/about/about.component';
import { SearchComponent } from './components/records/search/search.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RegistrationListComponent,
    RegistrationAddComponent,
    RegistrationEditComponent,
    RegistrationDetailsComponent,
    AttendanceListComponent,
    AttendanceAddComponent,
    AttendanceDetailsComponent,
    AddOpdComponent,
    ListOpdComponent,
    AboutComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    CustomFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'about', component: AboutComponent },
      { path: 'search', component: SearchComponent },
      { path: 'registration', component: RegistrationListComponent, resolve: { patients: PatientsResolverService } },
      { path: 'attendance', component: AttendanceListComponent, resolve: { list: AttendanceResolverService } },
      { path: 'vital-signs', component: ListOpdComponent, resolve: { list: VitalsResolverService } }
    ])
  ],
  providers: [
    OpdHttpService,
    RegisterHttpService,
    FindPatientResolverService,
    PatientsResolverService,
    AttendanceHttpService,
    AttendanceResolverService,
    VitalsResolverService,
    OpdHttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
