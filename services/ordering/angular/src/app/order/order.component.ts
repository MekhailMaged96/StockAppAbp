import { OrderService } from './../proxy/orders/order.service';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component } from '@angular/core';
import { OrderDto } from '../proxy/orders';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-order',
  standalone: false,
  templateUrl: './order.component.html',
  styleUrl: './order.component.scss',
})
export class OrderComponent {
  order = { items: [], totalCount: 0 } as PagedResultDto<OrderDto>;

  selectedorder = {} as OrderDto; // declare selectedBook

  form: FormGroup;

  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private orderService: OrderService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {}

  ngOnInit() {
    const orderStream = query => this.orderService.getList(query);

    this.list.hookToQuery(orderStream).subscribe(response => {
      this.order = response;
    });
  }

  createorder() {
    this.selectedorder = {} as OrderDto; // reset the selected book
    this.buildForm();
    this.isModalOpen = true;
  }

  buildForm() {
    this.form = this.fb.group({
      productName: [this.selectedorder.productName || '', Validators.required],
      quantity: [this.selectedorder.quantity || null, Validators.required],
    });
  }

  // change the save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.orderService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
