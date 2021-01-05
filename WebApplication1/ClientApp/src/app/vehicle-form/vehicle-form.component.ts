import { Component, OnInit } from "@angular/core";
import { VehicleService } from "./Services/MakeService";

@Component({
  selector: 'vehicle-form',
  templateUrl: 'vehicle-form.component.html',
})
export class VehicleFormComponent implements OnInit {

  makes: any[];
  features: any[];
  models: any[];
  vehicle: any = {};

  constructor(private vehicleService: VehicleService) { }
  ngOnInit() {
    this.vehicleService.getMakes().subscribe(data => {
      this.makes = data
    });
    this.vehicleService.getFeatures().subscribe(data => {
      this.features = data
    });
  }

  OnMakeChange() {
    var selectedMake = this.makes.find(x => x.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];
  }
}
