import { ProductService } from './../proxy/product.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductDto } from '../proxy/products';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-product',
  standalone: false,
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss',
})
export class ProductComponent {
  product = { items: [], totalCount: 0 } as PagedResultDto<ProductDto>;

  selectedProduct = {} as ProductDto; // declare selectedBook

  form: FormGroup;

  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private productService: ProductService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {}

  ngOnInit() {
    const prodcutStream = query => this.productService.getList(query);

    this.list.hookToQuery(prodcutStream).subscribe(response => {
      this.product = response;
    });
  }

  createProduct() {
    this.selectedProduct = {} as ProductDto; // reset the selected book
    this.buildForm();
    this.isModalOpen = true;
  }

  editProduct(id: string) {
    this.productService.get(id).subscribe(book => {
      this.selectedProduct = book;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.productService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedProduct.name || '', Validators.required],
      quantity: [this.selectedProduct.quantity || null, Validators.required],
    });
  }

  // change the save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedProduct.id
      ? this.productService.update(this.selectedProduct.id, this.form.value)
      : this.productService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
