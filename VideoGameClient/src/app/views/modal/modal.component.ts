import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal',
  template: `
    <div class="modal-body text-center">
      <p>{{message}}</p>
    </div>
    <div *ngIf="allowClose" class="modal-footer">
      <button type="button" class="btn btn-outline-dark" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `
})
export class ModalComponent implements OnInit {
  @Input() message;
  @Input() allowClose;

  constructor(public activeModal: NgbActiveModal) {}
  ngOnInit(): void {
  }

}