

namespace Cppia.NET.Instructions;

public abstract class CppiaInstruction
{   
    // Todo: Make abstract
    public virtual object? Emit(Mono.Cecil.Cil.ILProcessor processor, Context context) => throw new NotImplementedException();
    
    public static CppiaInstruction ReadInstruction(CppiaFile file, CppiaReader reader)
    {
        //int fileId = reader.ReadByte();
        //int line = reader.ReadByte();
        var code = (CppiaOpCode)reader.ReadByte();
        return code switch
        {
            // Declaration
            CppiaOpCode.IaFun => new FunctionInstruction(file, reader),
            CppiaOpCode.IaEnumI => new EnumIInstruction(file, reader),
            CppiaOpCode.IaObjDef => new ObjectDefInstruction(file, reader),
            CppiaOpCode.IaBlock => new BlockInstruction(file, reader),
            CppiaOpCode.IaPosInfo => new PosInfoInstruction(file, reader),
            
            CppiaOpCode.IaFEnum => new EnumFieldInstruction(file, reader, false),
            CppiaOpCode.IaCreateEnum => new EnumFieldInstruction(file, reader, true),
            CppiaOpCode.IaNew => new NewInstruction(file, reader),
            
            //CppiaOpCode.IaInline => throw new NotImplementedException(),
            // CppiaOpCode.IaInterface => throw new NotImplementedException(),
            // CppiaOpCode.IaEnum => throw new NotImplementedException(),
            // CppiaOpCode.IaMain => throw new NotImplementedException(),
            // CppiaOpCode.IaNoMain => throw new NotImplementedException(),
            // CppiaOpCode.IaResources => throw new NotImplementedException(),
            // CppiaOpCode.IaClass => throw new NotImplementedException(),
            //CppiaOpCode.IaImplDynamic => throw new NotImplementedException(),
            //      Access
            // CppiaOpCode.IaAccessNormal => throw new NotImplementedException(),
            // CppiaOpCode.IaAccessNot => throw new NotImplementedException(),
            // CppiaOpCode.IaAccessResolve => throw new NotImplementedException(),
            // CppiaOpCode.IaAccessCall => throw new NotImplementedException(),
            // Creation
            // CppiaOpCode.IaVarDecl => throw new NotImplementedException(),
            // CppiaOpCode.IaVarDeclI => throw new NotImplementedException(),
            //CppiaOpCode.IaAccessCallNative => throw new NotImplementedException(),
            //CppiaOpCode.IaReso => throw new NotImplementedException(),

            // Callable
            CppiaOpCode.IaCall => new CallInstruction(file, reader),
            CppiaOpCode.IaCallGlobal => new CallGlobalInstruction(file, reader),
            CppiaOpCode.IaCallStatic => new CallStaticInstruction(file, reader),
            CppiaOpCode.IaCallMember => new CallMemberInstruction(file, reader),
            CppiaOpCode.IaCallSuper => new CallSuperInstruction(file, reader),
            CppiaOpCode.IaCallThis => new CallThisInstruction(file, reader),
            CppiaOpCode.IaCallSuperNew => new CallSuperNewInstruction(file, reader),

            // Fields
            CppiaOpCode.IaFStatic => new GetStaticFieldInstruction(file, reader),
            CppiaOpCode.IaFLink => new GetFieldByLinkInstruction(file, reader, false),
            CppiaOpCode.IaFName => new GetFieldInstruction(file, reader),
            CppiaOpCode.IaFThisName => new GetThisFieldInstruction(file, reader),
            CppiaOpCode.IaFThisInst => new GetFieldByLinkInstruction(file, reader, true),
     
            // Vars
            CppiaOpCode.IaTVars => new TVarsInstruction(file, reader),
            CppiaOpCode.IaVar => new VaribleInstruction(file, reader),
            
            // Arrays
            CppiaOpCode.IaADef => new ArrayDefInstruction(file, reader),
            CppiaOpCode.IaArrayI => new ArrayIInstruction(file, reader),

            // Uniops
            CppiaOpCode.IaPlusPlus => new PreincrInstruction(file ,reader),
            CppiaOpCode.IaPlusPlusPost => new PostIncrInstruction(file ,reader),
            CppiaOpCode.IaMinusMinus => new PreDecrInstruction(file ,reader),
            CppiaOpCode.IaMinusMinusPost => new PreDecrInstruction(file ,reader),
            CppiaOpCode.IaSet => new SetInstruction(file, reader),

            // Casting
            CppiaOpCode.IaToInterface => new ToInterfaceInstruction(file, reader, false),
            CppiaOpCode.IaToInterfaceArray => new ToInterfaceInstruction(file, reader, true),
            CppiaOpCode.IaToDynArray => new CastInstruction(file, reader, CastInstruction.CastOpCode.CastDynArray),
            CppiaOpCode.IaToDataArray => new CastInstruction(file, reader,CastInstruction.CastOpCode.CastDataArray),
            CppiaOpCode.IaCast => new CastInstruction(file, reader,CastInstruction.CastOpCode.CastDynamic),
            CppiaOpCode.IaCastInt => new CastInstruction(file, reader, CastInstruction.CastOpCode.CastInt),
            CppiaOpCode.IaCastBool => new CastInstruction(file, reader,CastInstruction.CastOpCode.CastBool),
            CppiaOpCode.IaTCast => new CastInstruction(file, reader,CastInstruction.CastOpCode.CastInstance),
            CppiaOpCode.IaNoCast => new CastInstruction(file, reader, CastInstruction.CastOpCode.CastNOP),
            
            // Constants
            CppiaOpCode.IaConstInt => new ConstIntInstruction(reader),
            CppiaOpCode.IaConstFloat => new ConstFloatInstruction(file, reader),
            CppiaOpCode.IaConstTrue => new ConstBoolInstruction(file, reader, true),
            CppiaOpCode.IaConstFalse => new ConstBoolInstruction(file, reader, false),
            CppiaOpCode.IaConstString => new ConstStringInstruction(file, reader),
            CppiaOpCode.IaConstNull => new ConstNullInstruction(),
            CppiaOpCode.IaConstThis => new ConstThisInstruction(),
            CppiaOpCode.IaConstSuper => new ConstSuperInstruction(),
            
            // Boolean opeartions
            CppiaOpCode.IaLogicNot => new LogicNotInstruction(file, reader),
            CppiaOpCode.IaIsNull => new IsNullInstruction(file, reader),
            CppiaOpCode.IaNotNull => new IsNotNullInstruction(file, reader),

            // Control flow
            CppiaOpCode.IaBreak => new BreakInstruction(),
            CppiaOpCode.IaContinue => new ContinueInstruction(),
            CppiaOpCode.IaIf => new IfInstruction(file, reader),
            CppiaOpCode.IaIfElse => new IfElseInstruction(file, reader),
            CppiaOpCode.IaThrow => new ThrowInstruction(file, reader),
            CppiaOpCode.IaReturn => new ReturnInstruction(),
            CppiaOpCode.IaRetVal => new ReturnValueInstruction(file, reader),
            CppiaOpCode.IaWhile => new WhileInstruction(file, reader),
            CppiaOpCode.IaFor => new ForInstruction(file, reader),
            CppiaOpCode.IaSwitch => new SwitchInstruction(file, reader),
            CppiaOpCode.IaTry => new TryInstruction(file, reader),
            
            CppiaOpCode.IaClassOf => new ClassOfInstruction(file, reader),
            
            // Binary/Number operations
            CppiaOpCode.IaNeg => new NegativeInstruction(file, reader),
            CppiaOpCode.IaBitNot => new BitNotInstruction(file, reader),
            CppiaOpCode.IaBinOpAdd => new AddInstruction(file, reader),
            CppiaOpCode.IaBinOpMult => new MultiplyInstruction(file, reader),
            CppiaOpCode.IaBinOpDiv => new DivideInstruction(file, reader),
            CppiaOpCode.IaBinOpSub => new SubdivideInstruction(file, reader),
            CppiaOpCode.IaBinOpAssign => throw new NotImplementedException(),
            CppiaOpCode.IaBinOpEq => new EqualsInstruction(file, reader),
            CppiaOpCode.IaBinOpNotEq => new NotEqualsInstruction(file, reader),
            CppiaOpCode.IaBinOpGte => new GteInstruction(file, reader),
            CppiaOpCode.IaBinOpLte => new LteInstruction(file, reader),
            CppiaOpCode.IaBinOpGt => new GtInstruction(file, reader),
            CppiaOpCode.IaBinOpLt => new LtInstruction(file, reader),
            CppiaOpCode.IaBinOpAnd => new AndInstruction(file, reader),
            CppiaOpCode.IaBinOpOr => new OrInstruction(file, reader),
            CppiaOpCode.IaBinOpXor => new XorInstruction(file, reader),
            CppiaOpCode.IaBinOpBoolAnd => new BoolAndInstruction(file, reader),
            CppiaOpCode.IaBinOpBoolOr => new BoolOrInstruction(file, reader),
            CppiaOpCode.IaBinOpShr => new ShrInstruction(file, reader),
            CppiaOpCode.IaBinOpUShr => new UShrInstruction(file, reader),
            CppiaOpCode.IaBinOpShl => new ShlInstruction(file, reader),
            CppiaOpCode.IaBinOpMod => new ModInstruction(file, reader),
            CppiaOpCode.IaBinOpInterval => new IntervalInstruction(file, reader),
            CppiaOpCode.IaBinOpArrow => new ArrowInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignAdd => new AssignAddInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignMult => new AssignMulInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignDiv => new AssignDivInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignSub => new AssignSubInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignAnd => new AssignAndInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignOr => new AssignOrInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignXor => new AssignXorInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignBoolAnd => new AssignBoolAndInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignBoolOr => new AssignBoolOrInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignShr => new AssignShrInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignUShr => new AssignUShrInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignShl => new AssignShlInstruction(file, reader),
            CppiaOpCode.IaBinOpAssignMod => new AssignModInstruction(file, reader),
            _ => throw new InvalidDataException("Invalid OpCode: " + code)
        };
    }

    public static void ReadInstructions(IList<CppiaInstruction> instructions, CppiaFile file, CppiaReader reader,int count)
    {
        for (int i = 0; i < count; i++)
            instructions.Add(ReadInstruction(file,reader));
    }
}