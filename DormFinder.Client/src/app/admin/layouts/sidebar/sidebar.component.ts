import { Component, OnInit } from '@angular/core';

interface MenuItem {
  route: string;
  label: string;
  icon: string;
}

const menuItems: MenuItem[] = [
  {
    route: '.',
    label: 'Dashboard',
    icon: 'dashboard',
  },
  {
    route: 'buildings',
    label: 'Buildings',
    icon: 'apartment',
  },
  {
    route: 'rooms',
    label: 'Rooms',
    icon: 'king_bed',
  },
  {
    route: 'leads',
    label: 'Leads',
    icon: 'message',
  },
  {
    route: 'tenants',
    label: 'Tenants',
    icon: 'people',
  },
  {
    route: 'charges',
    label: 'Charges',
    icon: 'calculate',
  },
  {
    route: 'billing',
    label: 'Billing Periods',
    icon: 'request_quote',
  },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
  readonly menuItems: MenuItem[] = menuItems;

  constructor() {}

  ngOnInit(): void {}
}
