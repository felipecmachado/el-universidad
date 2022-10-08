import { Component, OnInit } from '@angular/core';
import { Offer } from '../models/offer.model';
import { OffersService } from '../services/offers.service';

@Component({
  selector: 'app-program-offers',
  templateUrl: './program-offers.component.html',
  styleUrls: ['./program-offers.component.scss']
})
export class ProgramOffersComponent implements OnInit {

  constructor(
    private offersService: OffersService) { }

  public offers: Offer[] = new Array<Offer>();

  ngOnInit(): void {
    this.getOffers();
  }

  getOffers() {
    this.offersService.getOffers().subscribe((data) => {
      this.offers = data.offers as Offer[];
    });
  }
}
