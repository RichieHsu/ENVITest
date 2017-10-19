import java.util.ArrayList;
import java.util.Calendar;

import com.tradevan.gateway.client.einv.parse.ParserException;
import com.tradevan.gateway.client.einv.parse.ParserHelper;
import com.tradevan.gateway.client.einv.transform.TransformException;
import com.tradevan.gateway.client.einv.transform.TransformHelper;
import com.tradevan.gateway.client.einv.validate.ValidateHelper;
import com.tradevan.gateway.client.einv.validate.proc.ValidateConstant;
import com.tradevan.gateway.client.einv.validate.proc.ValidateResult;
import com.tradevan.gateway.einv.msg.EINVPayload;
import com.tradevan.gateway.einv.msg.v31.A0101;
import com.tradevan.gateway.einv.msg.v31.A0101Body.AmountType;
import com.tradevan.gateway.einv.msg.v31.A0101Body.DetailsType;
import com.tradevan.gateway.einv.msg.v31.A0101Body.MainType;
import com.tradevan.gateway.einv.msg.v31.A0101Body.ProductItem;
import com.tradevan.gateway.einv.msg.v31.UtilBody.DonateMarkEnum;
import com.tradevan.gateway.einv.msg.v31.UtilBody.InvoiceTypeEnum;
import com.tradevan.gateway.einv.msg.v31.UtilBody.RoleDescriptionType;
import com.tradevan.gateway.einv.msg.v31.UtilBody.TaxTypeEnum;

public class GenMig {	

	public static A0101 genA0101Invoice() {

		 A0101 payLoad = new A0101();	 
		 
		 MainType mainType = new MainType();
		 mainType.setInvoiceNumber("DX12345678");
		 mainType.setInvoiceDate(Calendar.getInstance().getTime());
		 mainType.setInvoiceTime(Calendar.getInstance().getTime());
		 
		 RoleDescriptionType seller = new RoleDescriptionType();
		 seller.setIdentifier("100000001");
		 seller.setName("廁所蹲");
		 
		 RoleDescriptionType buyer = new RoleDescriptionType();
		 buyer.setIdentifier("100000001");
		 buyer.setName("家裡蹲");
		 
		 
		 mainType.setSeller(seller);
		 mainType.setBuyer(buyer);
		 
		 mainType.setInvoiceType(InvoiceTypeEnum.SixGeneralTaxType);
		 mainType.setDonateMark(DonateMarkEnum.NotDonated);
		 
		 DetailsType detailsType = new DetailsType();
		 
		 ArrayList<ProductItem> productItems = new ArrayList<ProductItem>();
		 ProductItem productItem = new ProductItem();
		 productItem.setDescription("測試品項1");
		 productItem.setQuantity("2");
		 productItem.setUnitPrice("100");
		 productItem.setAmount("200");
		 productItem.setSequenceNumber("1");
		 
		 productItems.add(productItem);
		 
		 
		 AmountType amountType = new AmountType();
		 
		 amountType.setSalesAmount(300L);
		 amountType.setTaxType(TaxTypeEnum.TaxFree);
		 amountType.setTaxRate("0");
		 amountType.setTaxAmount(0L);
		 amountType.setTotalAmount(300L);
		 
		 payLoad.setMain(mainType);	 		 
		 payLoad.setDetails(detailsType);
		 payLoad.setAmount(amountType);
		 
		return payLoad;
	}
	
	public static void main(String[] args) throws Exception {

		 try {
			 EINVPayload payLoad = null;
			 
			 payLoad = genA0101Invoice();
			 
			 TransformHelper transformHelper = new TransformHelper();

			 EINVPayload latestPayLoad = transformHelper.transformToNewestVersion(payLoad);
			 ParserHelper helper = new ParserHelper();
			 
			 String xml = helper.marshalToXML(latestPayLoad);
			 ValidateHelper validateHelper = new ValidateHelper();
			 ValidateResult validateResult = validateHelper.validateXML(xml, latestPayLoad.getClass());

			 
			 if(ValidateConstant.SUCESS[0] != validateResult.getErrorCode()) {
				 throw validateResult.getException();
			 }else {

				 System.out.println("產生xml完成!");
				 System.out.println(xml);
			 }
			 
			} catch (TransformException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();

			} catch (ParserException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		 
		 
		 
	}
	
	

}
