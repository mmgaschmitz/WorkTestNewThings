
import { useForm, SubmitHandler} from "react-hook-form"
import { yupResolver } from "@hookform/resolvers/yup"
import * as yup from "yup"
import { useState } from "react"

// https://strapi.io/blog/yup-validation-in-react-hook-form-a-complete-guide-with-examples
// https://react-hook-form.com/get-started

type InputsDataType = {
  example: string,
  exampleRequired: string,
  leeftijd: number
}


export default function App() {

  const myInitData: InputsDataType  = {
  example: "Hello",
  exampleRequired: "Example Tekst",
  leeftijd: 18
  }

  const [myData, setMyData] = useState<InputsDataType>(myInitData);

  console.log("Current myData:", myData)

  const InputsSchema = yup.object().shape(
    {
      example: yup
      .string()
      .nullable()
      .trim()
      .uppercase()
      .required("example is verplicht"),
      exampleRequired:  yup
      .string()
      .required("exampleRequired is verplicht")
      .trim(),
      leeftijd: yup
      .number()
      .typeError("Moet een getal zijn")
      .required("Leedtijd is verplicht")
      .min(10, "Mininmaal 10")
      .max(60, "Maximaal 60"),
    }
  );

  // type InputsSchemaType = yup.InferType<typeof InputsSchema>;

    // Validate to yup schema as test.
  // try
  // {
  //   InputsSchema.validateSync(myData);
  // }
  // catch(error)
  // {
  //   let message
  //   if (error instanceof Error) message = error.message
  //   else message = String(error)
  //   console.log(message);
  // } 


  const {
    register,
    handleSubmit,
    watch,
    reset,
    formState: { errors },
  } = useForm<InputsDataType>(
    {
       resolver: yupResolver(InputsSchema),
       defaultValues: myInitData,
  });



    // Submit handler
    const onSubmit: SubmitHandler<InputsDataType> = (data) => {
      console.log(data);
      setMyData(data);
      reset(data);
    };


  console.log(watch("example")) // watch input value by passing the name of it


  return (
    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */
    <form onSubmit={handleSubmit(onSubmit)}>
        <h3>Fields in a form</h3>
    
      <p>
        {/* register your input into the hook by invoking the "register" function */}
        <input {...register("example")} />
      </p>
        <p>
        {/* include validation with required or other standard HTML validation rules */}
        <input {...register("exampleRequired")} />
        {/* errors will return when field validation fails  */}
      </p>
      <p>
        <input {...register("leeftijd")}></input>
      </p>
      <h3>Errror's</h3>
        {errors.exampleRequired && (
          <div>
            <h4>ExampleRequired fouten</h4>
            <p>{errors.exampleRequired.message}</p>
          </div>
          )
        }
        {errors.leeftijd && (
          <div>
            <h4>Leeftijd fouten</h4>
            <p>{errors.leeftijd.message}</p>
          </div>
          )
        }
      <input type="submit" />
    </form>
  )
}