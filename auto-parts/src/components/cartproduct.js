import styled from 'styled-components';
import { TextField, Typography, Button } from '@material-ui/core';
import { Box } from '@mui/system';
import { useState } from 'react';
import { red } from '@mui/material/colors';

const Product = styled.div`
  display: flex;
  justify-content: space-between;
`;

const ProductDetail = styled.div`
  flex: 2;
  display: flex;
`;

const Details = styled.div`
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
`;

const PriceDetail = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

const Hr = styled.hr`
  background-color: #eee;
  border: none;
  height: 1px;
`;

const CartProduct = props => {
  const { itemId, title, price, imgSrc, isAddedToCart } = props;

  const [quantity, setQuantity] = useState(props.quantity);
  var totalProductPrice = price * quantity;
  console.log('CartProduct', props, quantity);

  return (
    <Box>
      <Product>
        <ProductDetail>
          <img src={imgSrc} width="200px" alt="Product" />
          <Details>
            <Typography variant="h6">
              <b>Product:</b> {title}
            </Typography>
            <Typography variant="h6">
              <b>Product ID:</b> {itemId}
            </Typography>
            <Typography variant="h6">
              <b>Price:</b> ${price}
            </Typography>
          </Details>
        </ProductDetail>
        <PriceDetail>
          <TextField
            id="quantity"
            margin="normal"
            variant="outlined"
            type="input"
            label="Quantity"
            value={quantity}
            style={{ width: 100 }}
            onChange={event => {
              const newQuantity = event.target.value;
              setQuantity(newQuantity);
              props.changeQuantity(itemId, newQuantity);
            }}
          />
          <Typography variant="h6">
            <b>Total price: ${parseFloat(totalProductPrice).toFixed(2)}</b>
          </Typography>
          <Button
            variant="contained"
            style={{ backgroundColor: red[500], color: red[50] }}
            aria-label="removeFromCart"
            onClick={() => props.removeFromCart(itemId)}
          >
            REMOVE FROM CART
          </Button>
        </PriceDetail>
      </Product>
      <Hr />
    </Box>
  );
};

export default CartProduct;
