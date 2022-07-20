import * as React from 'react';
import { styled } from '@mui/material/styles';
import Card from '@mui/material/Card';
import CardHeader from '@mui/material/CardHeader';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import CardActions from '@mui/material/CardActions';
import Collapse from '@mui/material/Collapse';
import Avatar from '@mui/material/Avatar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import { red } from '@mui/material/colors';
import FavoriteBorderIcon from '@mui/icons-material/FavoriteBorder';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import FavoriteOutlinedIcon from '@mui/icons-material/FavoriteOutlined';
import { Button } from '@material-ui/core';
import { Box } from '@mui/system';
import { lightGreen } from '@mui/material/colors';

const ExpandMore = styled(props => {
  const { expand, ...other } = props;
  return <IconButton {...other} />;
})(({ theme, expand }) => ({
  transform: !expand ? 'rotate(0deg)' : 'rotate(180deg)',
  marginLeft: 'auto',
  transition: theme.transitions.create('transform', {
    duration: theme.transitions.duration.shortest,
  }),
}));

const ProductCard = props => {
  const [expanded, setExpanded] = React.useState(false);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };

  const {
    avatar,
    title,
    price,
    description,
    imgSrc,
    specifications,
    partId,
    isAddedToFavorites,
    carDetails,
  } = props;

  const carDetailsShown = `For: ${carDetails.make} ${carDetails.model}, 
  ${carDetails.fabricationYear}, ${carDetails.fuelType}, ${carDetails.cubicCapacity} cmc`;

  return (
    <Card>
      <CardHeader
        avatar={<Avatar sx={{ bgcolor: red[500] }}>{avatar}</Avatar>}
        action={
          <IconButton
            aria-label="add to favorites"
            onClick={() =>
              isAddedToFavorites
                ? props.removeFromFavorites(partId)
                : props.addToFavorites(partId)
            }
          >
            {isAddedToFavorites ? (
              <FavoriteOutlinedIcon style={{ color: 'F50057' }} />
            ) : (
              <FavoriteBorderIcon />
            )}
          </IconButton>
        }
        title={title}
        subheader={'$' + price}
      />
      <CardMedia
        style={{
          display: 'flex',
          flexDirection: 'column',
          justifyContent: 'center',
          alignItems: 'center',
        }}
      >
        <Typography>{carDetailsShown}</Typography>
        <img
          src={imgSrc}
          alt="Product"
          style={{
            maxWidth: '280px',
            maxHeight: '280px',
            objectFit: 'contain',
          }}
        ></img>
      </CardMedia>

      <CardActions>
        <Box sx={{ flexGrow: 1 }}>
          <Button
            variant="contained"
            color="secondary"
            aria-label="addToCart"
            onClick={() => props.addToCart(partId)}
          >
            ADD TO CART
          </Button>
        </Box>
        <ExpandMore
          expand={expanded}
          onClick={handleExpandClick}
          aria-expanded={expanded}
          aria-label="show more"
        >
          <ExpandMoreIcon />
        </ExpandMore>
      </CardActions>

      <Collapse in={expanded} timeout="auto" unmountOnExit>
        <CardContent>
          <Typography paragraph>Details: </Typography>
          <Typography paragraph>{description}</Typography>
          <Typography paragraph>Category: </Typography>
          <Typography paragraph>{specifications}</Typography>
        </CardContent>
      </Collapse>
    </Card>
  );
};

export default ProductCard;
