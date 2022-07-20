import { Grid, TextField, Typography } from '@material-ui/core';
import ProductCard from '../components/productcard';
import { useEffect, useState } from 'react';

const ProductCardsContainer = props => {
  const { parts = [], isLoadingParts = false } = props;
  const [searchBy, setSearchBy] = useState('');

  useEffect(() => {
    props.fetchParts();
  }, []);

  if (isLoadingParts)
    return (
      <Grid align="center">
        <Typography>Loading parts...</Typography>
      </Grid>
    );

  return (
    <Grid>
      <Grid align="center">
        <TextField
          margin="normal"
          variant="outlined"
          type="input"
          label="Search for a part"
          onChange={event => {
            setSearchBy(event.target.value);
          }}
        />
      </Grid>
      <Grid
        container
        spacing={5}
        direction="row"
        justifyContent="space-evenly"
        alignItems="center"
      >
        {parts &&
          parts
            .filter(value => {
              if (searchBy === '') {
                return value;
              } else if (
                value.name.toLowerCase().includes(searchBy.toLowerCase())
              ) {
                return value;
              }
            })
            .map((part, key) => (
              <Grid item xs={12} sm={4}>
                <ProductCard
                  avatar={part.name[0]}
                  title={part.name}
                  price={part.price}
                  imgSrc={part.imgUrl}
                  isAddedToFavorites={part.isAddedToFavorites}
                  description={part.description}
                  specifications={part.category}
                  partId={part.partModelId}
                  carDetails={part.car}
                  addToCart={props.addToCart}
                  addToFavorites={props.addToFavorites}
                  removeFromFavorites={props.removeFromFavorites}
                />{' '}
              </Grid>
            ))}
      </Grid>
    </Grid>
  );
};

export default ProductCardsContainer;
