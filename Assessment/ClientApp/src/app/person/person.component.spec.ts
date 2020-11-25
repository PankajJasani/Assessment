import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonComponent } from './person.component';

describe('PersonComponent', () => {
  let fixture: ComponentFixture<PersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonComponent);
    fixture.detectChanges();
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Persons');
  }));

  it('should start with count 0, then increments by 1 when clicked', async(() => {
    const countElement = fixture.nativeElement.querySelector('strong');
    expect(countElement.textContent).toEqual('0');

    const incrementButton = fixture.nativeElement.querySelector('button');
    incrementButton.click();
    fixture.detectChanges();
    expect(countElement.textContent).toEqual('1');
  }));
});
