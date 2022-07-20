import styled from 'styled-components';
import Button from '@mui/material/Button';
import history from '../history/history';
import { Typography, Grid } from '@material-ui/core';
import { Box } from '@mui/system';
import { red, lightGreen } from '@mui/material/colors';
import CartProduct from './cartproduct';
import { useEffect } from 'react';

const Info = styled.div`
  flex: 3;
`;
const Summary = styled.div`
  flex: 1;
  border: 0.5px solid lightgray;
  border-radius: 10px;
  padding: 20px;
  height: 50vh;
`;

const SummaryItem = styled.div`
  margin: 30px 0px;
  display: flex;
  justify-content: space-between;
  font-weight: ${props => props.type === 'total' && '500'};
  font-size: ${props => props.type === 'total' && '24px'};
`;

const Cart = props => {
  const { parts = [], isLoadingParts = false } = props;
  const partsAddedToCart = parts.filter(part => part.isAddedToCart);
  const totalSum = partsAddedToCart.reduce((acc, part) => {
    acc += part.quantity * part.price;
    return acc;
  }, 0);

  useEffect(() => {
    props.fetchParts();
  }, []);

  if (isLoadingParts)
    return (
      <Grid align="center">
        <Typography>Loading cart...</Typography>
      </Grid>
    );

  return (
    <Box>
      <Box sx={{ bgcolor: '#002984' }}>
        <Typography align="center" style={{ color: red[50] }}>
          Free Shipping Just This Weekend!
        </Typography>
      </Box>
      <Box style={{ padding: '20px' }}>
        <Box sx={{ bgcolor: '#002984', maxWidth: 230, margin: 'auto' }}>
          <Typography align="center" variant="h4" style={{ color: red[50] }}>
            YOUR CART
          </Typography>
        </Box>
        <Box style={{ display: 'flex' }}>
          <Info>
            {partsAddedToCart.map((part, key) => {
              return (
                <CartProduct
                  itemId={part.partModelId}
                  title={part.name}
                  price={part.price}
                  imgSrc={part.imgUrl}
                  isAddedToCart={part.isAddedToCart}
                  quantity={part.quantity}
                  totalSum={props.totalSum}
                  addToTotalSum={props.addToTotalSum}
                  changeQuantity={props.changeQuantity}
                  removeFromCart={props.removeFromCart}
                  description="This is where part's CAR details will go"
                />
              );
            })}
          </Info>

          <Summary>
            <Typography variant="h4">ORDER SUMMARY</Typography>
            <SummaryItem>
              <Typography>Subtotal</Typography>
              <Typography>${parseFloat(totalSum).toFixed(2)}</Typography>
            </SummaryItem>
            <SummaryItem>
              <Typography>Estimated Shipping</Typography>
              <Typography>$ 5.90</Typography>
            </SummaryItem>
            <SummaryItem>
              <Typography>Shipping Discount</Typography>
              <Typography>$ -5.90</Typography>
            </SummaryItem>
            <SummaryItem type="total">
              <Typography variant="h5">
                <b>Total: </b>
              </Typography>
              <Typography variant="h5">
                <b>${parseFloat(totalSum).toFixed(2)} </b>
              </Typography>
            </SummaryItem>
            <Button
              variant="contained"
              color="primary"
              size="medium"
              onClick={() => history.push('/Products')}
            >
              CONTINUE SHOPPING
            </Button>
            <Button
              variant="contained"
              size="medium"
              style={{ backgroundColor: lightGreen[700], marginLeft: '17px' }}
              onClick={() => history.push('/ToBeContinued')}
            >
              CHECKOUT NOW
            </Button>
          </Summary>
        </Box>
      </Box>
    </Box>
  );
};

export default Cart;
