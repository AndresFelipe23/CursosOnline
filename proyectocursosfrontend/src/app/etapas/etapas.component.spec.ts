import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EtapasComponent } from './etapas.component';

describe('EtapasComponent', () => {
  let component: EtapasComponent;
  let fixture: ComponentFixture<EtapasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EtapasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EtapasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
