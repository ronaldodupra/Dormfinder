import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'base-component',
  templateUrl: './base-component.component.html',
  styleUrls: ['./base-component.component.css'],
  host: { 'class': 'content-area dox-content-panel' }
})
export class BaseComponentComponent implements OnInit {

  @Input() title: string;
  constructor() { }

  ngOnInit() {
  }

}
