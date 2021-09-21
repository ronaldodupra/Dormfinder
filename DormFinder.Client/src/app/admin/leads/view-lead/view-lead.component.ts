import { IAddlead } from 'src/app/models/lead.model';
import { LeadService } from 'src/app/services/lead.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-lead',
  templateUrl: './view-lead.component.html',
  styleUrls: ['./view-lead.component.scss'],
})
export class ViewLeadComponent implements OnInit {
  constructor(private route: ActivatedRoute, private leadService: LeadService) {
    this.leadId = this.route.snapshot.paramMap.get('id');
  }

  leadId: string;

  lead: IAddlead;

  ngOnInit(): void {
    this.leadById(this.leadId);
  }
  public leadById(Id) {
    this.leadService
      .getLeadById(Id)
      .subscribe((result) => (this.lead = result));
  }
}
