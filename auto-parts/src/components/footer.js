import styled from 'styled-components';
import { Facebook, Instagram, MailOutline, Phone } from '@mui/icons-material';

const Container = styled.div`
  display: flex;
  width: 100vw;
  background-color: #3f51b5;
  color: white;
  position: fixed;
  bottom: 0;
`;
const Left = styled.div`
  flex: 1;
  max-width: 20vw;
  padding: 0 20px 5px;
`;

const Name = styled.h1`
  margin: 10px 0;
`;

const Desc = styled.p`
  margin: 20px 0px;
`;

const SocialContainer = styled.div`
  display: flex;
  position: absolute;
  bottom: 3px;
`;

const SocialIcon = styled.div`
  width: 40px;
  height: 40px;
  border-radius: 50%;
  color: white;
  background-color: #${props => props.color};
  display: flex;
  align-items: center;
  justify-content: center;
  margin-right: 20px;
  margin-bottom: 0;
`;

const Center = styled.div`
  padding: 0 20px;
  display: flex;
  flex: 1;
  align-items: center;
  justify-content: center;
`;

const Right = styled.div`
  align-items: right;
  padding: 0 20px;
`;
const Title = styled.h3`
  margin-top: 10px;
  margin-bottom: 20px;
`;

const ContactItem = styled.div`
  margin-bottom: 20px;
  display: flex;
  align-items: center;
`;

const Payment = styled.img`
  width: 200px;
  height: 22px:
`;

const Footer = () => {
  return (
    <Container>
      <Left>
        <Name>CarLounge</Name>
        <Desc>
          Never let your car feel left out of your life. Keep it maintained,
          using the most reliable parts provider.
        </Desc>
        <SocialContainer>
          <a
            href="https://www.facebook.com/mladin.rares/"
            rel="noreferrer"
            target="_blank"
          >
            <SocialIcon color="2196f3">
              <Facebook />
            </SocialIcon>
          </a>
          <a
            href="https://www.instagram.com/rares.mladin/"
            rel="noreferrer"
            target="_blank"
          >
            <SocialIcon color="F50057">
              <Instagram />
            </SocialIcon>
          </a>
        </SocialContainer>
      </Left>
      <Center>
        <img
          src="/images/LogoWhite.png"
          alt="White CarLounge logo"
          style={{ position: 'fixed', right: '41%' }}
        />
      </Center>
      <Right>
        <Title>Contact</Title>
        <ContactItem>
          <Phone style={{ marginRight: '10px' }} /> +0712 345 678
        </ContactItem>
        <ContactItem>
          <MailOutline style={{ marginRight: '10px' }} /> contact@carlounge.com
        </ContactItem>
        <Payment src="https://i.ibb.co/Qfvn4z6/payment.png" />
      </Right>
    </Container>
  );
};

export default Footer;
