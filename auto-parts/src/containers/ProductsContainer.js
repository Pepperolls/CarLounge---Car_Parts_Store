import { Grid } from '@material-ui/core';
import Footer from '../components/footer';
import ProductCardsContainer from './ProductCardsContainer';
import { Box } from '@mui/system';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as productActions from '../redux/actions/productActions';

const ProductsContainer = props => {
  return (
    <Grid>
      <Box mb={30}>
        <Grid container>
          <Grid item xs={false} sm={2} />
          <Grid item xs={12} sm={8}>
            <ProductCardsContainer
              parts={props.parts}
              isLoadingParts={props.isLoadingParts}
              fetchParts={props.fetchParts}
              addToCart={props.addToCart}
              addToFavorites={props.addToFavorites}
              removeFromFavorites={props.removeFromFavorites}
            />
          </Grid>
          <Grid item xs={false} sm={2} />
        </Grid>
      </Box>
      <Footer />
    </Grid>
  );
};

function mapStateToProps(state) {
  const {
    products: {
      parts,
      partsAddedToCart,
      partsAddedToFavorites,
      isLoadingParts,
    },
  } = state;
  return {
    parts: parts.map(p => {
      const isAddedToCart = partsAddedToCart.includes(p.partModelId);
      const isAddedToFavorites = partsAddedToFavorites.includes(p.partModelId);
      return { ...p, isAddedToCart, isAddedToFavorites };
    }),

    isLoadingParts,
  };
}

function mapDispatchToProps(dispatch) {
  return { ...bindActionCreators(productActions, dispatch) };
}

export default connect(mapStateToProps, mapDispatchToProps)(ProductsContainer);
