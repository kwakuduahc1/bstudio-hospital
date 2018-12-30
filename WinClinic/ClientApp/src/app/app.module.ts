import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CustomFormsModule } from 'ng2-validation'
import { NgPipesModule } from 'ngx-pipes';

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
import { DiagnosesHttpService } from './http/consulting/diagnoses-http.service';
import { DiscountsResolver } from './resolvers/consulting/dIscounts-resolver';
import { DiscountsHttpService } from './http/consulting/discounts-http.service';
import { SummarytHttpService } from './http/consulting/summary-http.service';
import { DatesResolver } from './resolvers/consulting/dates-resolver';
import { LoginGuard } from './guards/LoginGuard';
import { StatusProvider } from './providers/StatusProvider';
import { RouteProvider } from './providers/RouteProvider';
import { FindParentPatientResolver } from './resolvers/consulting/find-patient-resolver';
import { PatientSummaryResolver } from './resolvers/consulting/patient-summary-resolver';
import { FilesResolver } from './resolvers/consulting/files-resolver';
import { PatientServicesResolver } from './resolvers/consulting/patient-services-resolver';
import { ServicesResolver } from './resolvers/consulting/services-resolver';
import { DrugsResolver } from './resolvers/consulting/drugs-resolver';
import { PatientLabsResolver } from './resolvers/consulting/patient-labs-resolver';
import { ConsultVitalsResolver } from './resolvers/consulting/consult-vitals-resolver';
import { HttpService } from './http/consulting/http.service';
import { ComplaintsComponent } from './components/consult/complaints/complaints.component';
import { HistoryResolver } from './resolvers/consulting/history-resolver';
import { PatientService } from './providers/patient-service';
import { ConsultHttpService } from './http/consulting/consult-http.service';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { DiagnosisComponent } from './components/consult/diagnosis/diagnosis.component';
import { PatientDiagnosesResolver } from './resolvers/consulting/patient-diagnoses-resolver';
import { DiagnosesListResolver } from './resolvers/consulting/diagnoses-list-resolver';
import { LabsComponent } from './components/consult/labs/labs.component';
import { LabsResolver } from './resolvers/consulting/labs-resolver';
import { LabsHttpService } from './http/consulting/labs-http.service';
import { DrugsComponent } from './components/consult/drugs/drugs.component';
import { PatientDrugsResolver } from './resolvers/consulting/patient-drugs-resolver';
import { DrugsHttpService } from './http/consulting/drugs-http.service';
import { CloseSessionComponent } from './components/close-session/close-session.component';
import { ActiveSessionResolverService } from './resolvers/attendance/active-session-resolver';
import { PaymentsComponent } from './components/accounts/payments/payments.component';
import { PaymnentsHttpService } from './http/payments/payments-http-service';

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
    PendingComponent,
    ComplaintsComponent,
    NotFoundComponent,
    DiagnosisComponent,
    LabsComponent,
    DrugsComponent,
    CloseSessionComponent,
    PaymentsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    CustomFormsModule,
    NgPipesModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'about', component: AboutComponent },
      { path: 'search', component: SearchComponent },
      { path: 'registration', component: RegistrationListComponent, resolve: { patients: PatientsResolverService } },
      { path: 'attendance', component: AttendanceListComponent, resolve: { list: AttendanceResolverService } },
      { path: 'vital-signs', component: ListOpdComponent, resolve: { list: VitalsResolverService } },
      { path: 'pending', component: PendingComponent },
      { path: 'active-session', component: CloseSessionComponent, resolve: { sessions: ActiveSessionResolverService } },
      { path: 'payments', component: PaymentsComponent },
      {
        path: 'consult/:id', component: ConsultHomeComponent, children: [
          { path: 'vitals', component: VitalsComponent, resolve: { vitals: ConsultVitalsResolver, patient: FindParentPatientResolver } },
          { path: 'complaints', component: ComplaintsComponent, resolve: { 'history': HistoryResolver, patient: FindParentPatientResolver } },
          { path: 'diagnose', component: DiagnosisComponent, resolve: { diags: DiagnosesListResolver, list: PatientDiagnosesResolver, patient: FindParentPatientResolver } },
          { path: 'labs', component: LabsComponent, resolve: { labs: LabsResolver, history: PatientLabsResolver, patient: FindParentPatientResolver } },
          { path: 'drugs', component: DrugsComponent, resolve: { drugs: DrugsResolver, patient: FindParentPatientResolver, history: PatientDrugsResolver } }
        ]
      },
      { path: '**', component: NotFoundComponent }
    ])
  ],
  providers: [
    DiagnosesListResolver,
    PatientService,
    HistoryResolver,
    ConsultHttpService,
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
    RouteProvider,
    StatusProvider,
    LoginGuard,
    DatesResolver,
    SummarytHttpService,
    DiscountsHttpService,
    DiscountsResolver,
    DiagnosesHttpService,
    PatientDiagnosesResolver,
    HttpService,
    ConsultVitalsResolver,
    LabsResolver,
    PatientLabsResolver,
    LabsHttpService,
    PatientDrugsResolver,
    DrugsResolver,
    DrugsHttpService,
    ActiveSessionResolverService,
    PaymnentsHttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
