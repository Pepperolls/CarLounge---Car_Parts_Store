import Cart from '../components/cart';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as productActions from '../redux/actions/productActions';

const CartContainer = props => {
  return (
    <Cart
      parts={props.parts}
      isLoadingParts={props.isLoadingParts}
      fetchParts={props.fetchParts}
      //addToCart={props.addToCart}
      removeFromCart={props.removeFromCart}
      addToTotalSum={props.addToTotalSum}
      totalSum={props.totalSum}
      changeQuantity={props.changeQuantity}
    />
  );
};

function mapStateToProps(state) {
  const {
    products: { parts, partsAddedToCart, isLoadingParts, totalSum },
  } = state;
  return {
    parts: parts.map(p => {
      const partAddedToCart = partsAddedToCart.find(
        part => part.partId == p.partModelId
      );
      console.log('Container log', partAddedToCart);
      return {
        ...p,
        isAddedToCart: partAddedToCart ? true : false,
        quantity: partAddedToCart ? partAddedToCart.quantity : 1,
      };
    }),
    isLoadingParts,
    totalSum,
  };
}

function mapDispatchToProps(dispatch) {
  return { ...bindActionCreators(productActions, dispatch) };
}

export default connect(mapStateToProps, mapDispatchToProps)(CartContainer);
