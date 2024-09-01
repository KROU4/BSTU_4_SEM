using Lab11.Data;
using Lab11.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Lab11.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ShopRepository _shopRepository;
        private ObservableCollection<Product> _products;
        private ObservableCollection<Product> _cartItems;
        private Product _selectedProduct;
        private Product _selectedCartItem;

        public MainViewModel()
        {
            _shopRepository = new ShopRepository();
            _products = new ObservableCollection<Product>(_shopRepository.GetAllProducts());
            _cartItems = new ObservableCollection<Product>(_shopRepository.GetCartItems());

            AddToCartCommand = new RelayCommand(AddToCart);
            RemoveFromCartCommand = new RelayCommand(RemoveFromCart);
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<Product> CartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                OnPropertyChanged(nameof(CartItems));
            }
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public Product SelectedCartItem
        {
            get { return _selectedCartItem; }
            set
            {
                _selectedCartItem = value;
                OnPropertyChanged(nameof(SelectedCartItem));
            }
        }

        public ICommand AddToCartCommand { get; }
        public ICommand RemoveFromCartCommand { get; }

        private void AddToCart()
        {
            if (SelectedProduct != null)
            {
                var existingItem = CartItems.FirstOrDefault(p => p.Id == SelectedProduct.Id);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    SelectedProduct.Quantity = 1; // или любое другое начальное количество
                    CartItems.Add(SelectedProduct);
                }
                _shopRepository.AddToCart(SelectedProduct.Id, SelectedProduct.Quantity);
            }
        }

        private void RemoveFromCart()
        {
            if (SelectedCartItem != null)
            {
                _shopRepository.RemoveFromCart(SelectedCartItem.Id);
                CartItems.Remove(SelectedCartItem);
            }
        }
    }
}
