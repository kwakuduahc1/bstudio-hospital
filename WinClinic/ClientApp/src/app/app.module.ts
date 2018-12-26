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
import { ConsultHomeComponent } from './components/consult/consult-home/consult-home.component';
import { VitalsComponent } from './components/consult/vitals/vitals.component';
import { PendingComponent } from './components/consult/pending/pending.component';
import { DiagnosesResolver } from './resolvers/consulting/diagnoses-resolver';
import { DiagnosesHttpService } from './http/consulting/diagnoses-http.service';
import { DiscountsResolver } from './resolvers/consulting/dIscounts-resolver';
import { DiscountsHttpService } from './http/consulting/discounts-http.service';
import { SummarytHttpService } from './http/consulting/summary-http.service';
import { DatesResolver } from './resolvers/consulting/dates-resolver';
import { LoginGuard } from './guards/LoginGuard';
import { StatusProvider } from './providers/StatusProvider';
import { RouteProvider } from './providers/RouteProvider';
import { VitalsResolver } from './resolvers/consulting/vitals-resolver';
import { FindParentPatientResolver } from './resolvers/consulting/find-patient-resolver';
import { PatientSummaryResolver } from './resolvers/consulting/patient-summary-resolver';
import { FilesResolver } from './resolvers/consulting/files-resolver';
import { PatientServicesResolver } from './resolvers/consulting/patient-services-resolver';
import { ServicesResolver } from './resolvers/consulting/services-resolver';
import { DrugsResolver } from './resolvers/consulting/drugs-resolver';
import { PatientLabsResolver } from './resolvers/consulting/patient-labs-resolver';

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
    SearchComponent,
    ConsultHomeComponent,
    VitalsComponent,
    PendingComponent
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
      { path: 'vital-signs', component: ListOpdComponent, resolve: { list: VitalsResolverService } },
      { path: 'pending', component: PendingComponent },
      {
        path: 'consult/:id', component: ConsultHomeComponent, children: [
          { path: 'vitals', component: VitalsComponent }
        ]
      }
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
    OpdHttpService,
    PatientLabsResolver,
    DrugsResolver,
    ServicesResolver,
    PatientServicesResolver,
    FilesResolver,
    PatientSummaryResolver,
    FindParentPatientResolver,
    VitalsResolver,
    RouteProvider,
    StatusProvider,
    LoginGuard,
    DatesResolver,
    SummarytHttpService,
    DiscountsHttpService,
    DiscountsResolver,
    DiagnosesHttpService,
    DiagnosesResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
